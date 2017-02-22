using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text.RegularExpressions;

namespace Cognitive_TEXT_API
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Process_Click(object sender, EventArgs e)
        {
            // Enable Buttons
            Process.Enabled = false;

            // Variables
            int SentimentID = 1;
            int SentenceID = 1;
            int KeyPhraseID = 1;
            int FileTotalLines = 0;
            int ProcessTotalErrors = 0;
            int ProgressIncAmt = 0;
            string InputFileTextLine;
            string[] InputFileSentences;
            string JSONCallString = "";
            string JSONCallResponse = "";
            string ResultLine;
            string ResultScore;
            string ResultKeyPhrases;
            string ResultKeyPhrasesListSring;
            string ResultErrors;
            string ResultErrorsListString;
            string strnow = DateTime.Now.ToString("yyyyMMddHHmmss");
            string FileLine;
            string FileName_Sentiment = OutputFile.Text + "\\AzureTextAPI_SentimentText_" + strnow + ".txt";
            string FileName_Phrases = OutputFile.Text + "\\AzureTextAPI_KeyPhrasesText_" + strnow + ".txt";
            string FileName_Sentence = OutputFile.Text + "\\AzureTextAPI_SentenceText_" + strnow + ".txt";
            List<string> ResultErrorsList;
            List<string> ResultKeyPhrasesList;
            JObject JSONObject;
            byte[] byteData;

            // Clear Text Box
            Results.Text = "";

            // Set progress to 0%
            ProgressBar.Value = 0;
            PctComplete.Text = ProgressBar.Value.ToString() + "%";
            Results.AppendText("Process Starting." + Environment.NewLine);
            Results.AppendText(Environment.NewLine);

            try
            {

                // Read Source file and get max lines
                System.IO.StreamReader file = new System.IO.StreamReader(SourceFile.Text);
                FileTotalLines = System.IO.File.ReadLines(SourceFile.Text).Count();

                // Set Progress Bar
                ProgressIncAmt = 100 / (FileTotalLines + 2);

                // Create 3x New Output Files and Write File Headers
                System.IO.StreamWriter streamWriter_Sentiment = new System.IO.StreamWriter(FileName_Sentiment);
                System.IO.StreamWriter streamWriter_Phrases = new System.IO.StreamWriter(FileName_Phrases);
                System.IO.StreamWriter streamWriter_Sentence = new System.IO.StreamWriter(FileName_Sentence);

                FileLine = "SentimentTextID" + "\t" + "SentimentTextLine" + "\t" + "SentimentTextScore";
                streamWriter_Sentiment.WriteLine(FileLine);

                FileLine = "SentimentTextID" + "\t" + "SentenceTextID" + "\t" + "SentenceTextLine" + "\t" + "SentenceTextScore";
                streamWriter_Sentence.WriteLine(FileLine);

                FileLine = "SentimentTextID" + "\t" + "KeyPhraseTextID" + "\t" + "KeyPhraseTextLine";
                streamWriter_Phrases.WriteLine(FileLine);


                ////////// START SENTIMENT PROCESS //////////

                Results.AppendText("Using Azure Cognitive API [" + TextAPIBaseURL.Text + TextAPIVersion.Text + "]." + Environment.NewLine);
                Results.AppendText(Environment.NewLine);
                ProgressBar.Value = ProgressBar.Value + ProgressIncAmt;
                PctComplete.Text = ProgressBar.Value.ToString() + "%";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(TextAPIBaseURL.Text);

                    // API Request Headers
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", APIKey.Text);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Display process line by line 
                    while ((InputFileTextLine = file.ReadLine()) != null)
                    {
                        // Remove double blanks, trim end of line
                        if (cbTrim.Checked == true)
                        {
                            InputFileTextLine = InputFileTextLine.Replace("  ", " ");
                            InputFileTextLine = InputFileTextLine.Trim();
                        }

                        // Replace TABS in Parse Text
                        if (cbReplaceTab.Checked == true)
                        {
                            if (cbTAB.SelectedIndex == 0) InputFileTextLine = InputFileTextLine.Replace("\t", " ");
                            if (cbTAB.SelectedIndex == 1) InputFileTextLine = InputFileTextLine.Replace("\t", ", ");
                        }

                        // Remove Hastags
                        if (cbHashtag.Checked == true)
                        {
                            InputFileTextLine = Regex.Replace(InputFileTextLine, @"#\S+ *", string.Empty);
                        }

                        // Remove URLs
                        if (cbURL.Checked == true)
                        {
                            InputFileTextLine = Regex.Replace(InputFileTextLine, @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)", string.Empty);
                        }

                        // Truncate Text to 10K (maximum document size for TEXT API)
                        if (cb1500.Checked == true)
                        {
                            //Console.WriteLine(System.Text.ASCIIEncoding.Unicode.GetByteCount(InputFileTextLine)); // <-- For debugging use.
                            if (System.Text.ASCIIEncoding.Unicode.GetByteCount(InputFileTextLine) > 10000)
                            {
                                InputFileTextLine = Truncate(InputFileTextLine, 10000);
                            }
                        }

                        ResultLine = "Reading File Text Line [ID: " + SentimentID + "]: " + InputFileTextLine;
                        Results.AppendText(ResultLine + Environment.NewLine);

                        if (InputFileTextLine.Trim() != "") // not a blank line
                        {
                            // Define Base JSON Call Request body used for both Sentiment and Key Phrases
                            JSONCallString = "{\"documents\":[{\"id\":\"" + SentimentID + "\",\"text\":\"" + InputFileTextLine.Replace("\"", "") + "\"}]}";
                            byteData = Encoding.UTF8.GetBytes(JSONCallString);


                            // KEY PHRASES
                            if (rbKeyPhrases.Checked == true)
                            {
                                ResultLine = "Detecting Text Line Key Phrases...";
                                Results.AppendText(ResultLine + Environment.NewLine);

                                JSONCallResponse = await CallEndpoint(client, TextAPIBaseURL.Text + TextAPIVersion.Text + "keyPhrases", byteData);
                                JSONObject = JObject.Parse(JSONCallResponse);

                                ResultErrors = (JSONObject["errors"]).ToString();
                                ResultErrorsList = JsonConvert.DeserializeObject<List<string>>(ResultErrors);
                                ResultErrorsListString = string.Join(", ", ResultErrorsList.ToArray());

                                if (ResultErrorsListString != "")
                                {
                                    ResultLine = "### ERROR ### [" + ResultErrorsListString + "]";
                                    Results.AppendText(ResultLine + Environment.NewLine);
                                    KeyPhraseID++;
                                    ProcessTotalErrors++;
                                }
                                else
                                {
                                    ResultKeyPhrases = (JSONObject["documents"][0]["keyPhrases"]).ToString();
                                    ResultKeyPhrasesList = JsonConvert.DeserializeObject<List<string>>(ResultKeyPhrases);
                                    ResultKeyPhrasesListSring = string.Join(", ", ResultKeyPhrasesList.ToArray());

                                    foreach (var ListItem in ResultKeyPhrasesList)
                                    {
                                        KeyPhraseID++;

                                        //Write to File
                                        FileLine = SentimentID.ToString() + "\t" + KeyPhraseID.ToString() + "\t" + ListItem;
                                        streamWriter_Phrases.WriteLine(FileLine);
                                    }

                                    ResultLine = "Key Phrases [" + ResultKeyPhrasesListSring + "]";
                                    Results.AppendText(ResultLine + Environment.NewLine);
                                }
                            }

                            // SENTIMENT - FULL TEXT
                            if (rbSentiment.Checked == true)
                            {
                                ResultLine = "Detecting Text Line Sentiment...";
                                Results.AppendText(ResultLine + Environment.NewLine);

                                JSONCallResponse = await CallEndpoint(client, TextAPIBaseURL.Text + TextAPIVersion.Text + "sentiment", byteData);
                                JSONObject = JObject.Parse(JSONCallResponse);

                                ResultErrors = (JSONObject["errors"]).ToString();
                                ResultErrorsList = JsonConvert.DeserializeObject<List<string>>(ResultErrors);
                                ResultErrorsListString = string.Join(", ", ResultErrorsList.ToArray());

                                if (ResultErrorsListString != "")
                                {
                                    ResultLine = "### ERROR ### [" + ResultErrorsListString + "]";
                                    Results.AppendText(ResultLine + Environment.NewLine);
                                    ProcessTotalErrors++;
                                }
                                else
                                {
                                    ResultScore = JSONObject["documents"][0]["score"].ToString();

                                    ResultLine = "Sentiment [" + ResultScore + "]";
                                    Results.AppendText(ResultLine + Environment.NewLine);

                                    //Write to File
                                    FileLine = SentimentID.ToString() + "\t" + InputFileTextLine + "\t" + ResultScore;
                                    streamWriter_Sentiment.WriteLine(FileLine);
                                }


                                // Split into Sentences
                                if (cbSplit.Checked == true)
                                {
                                    ResultLine = "Splitting Text Line into Sentences ...";
                                    Results.AppendText(ResultLine + Environment.NewLine);

                                    InputFileSentences = Regex.Split(InputFileTextLine, @"(?<=[\w\s](?:[\.\!\? ]+[\x20]*[\x22\xBB]*))(?:\s+(?![\x22\xBB](?!\w)))");

                                    foreach (var Sentence in InputFileSentences)
                                    {
                                        ResultLine = "Reading Sentence Text Line [ID: " + SentimentID + "." + SentenceID + "]: " + Sentence;
                                        Results.AppendText(ResultLine + Environment.NewLine);

                                        // Define JSON Call Request body
                                        JSONCallString = "{\"documents\":[{\"id\":\"" + SentimentID + "\",\"text\":\"" + Sentence.Replace("\"", "") + "\"}]}";
                                        byteData = Encoding.UTF8.GetBytes(JSONCallString);

                                        // SENTIMENT - SENTENCE TEXT
                                        ResultLine = "Detecting Sentiment in Sentence...";
                                        Results.AppendText(ResultLine + Environment.NewLine);

                                        JSONCallResponse = await CallEndpoint(client, TextAPIBaseURL.Text + TextAPIVersion.Text + "sentiment", byteData);
                                        JSONObject = JObject.Parse(JSONCallResponse);

                                        ResultErrors = (JSONObject["errors"]).ToString();
                                        ResultErrorsList = JsonConvert.DeserializeObject<List<string>>(ResultErrors);
                                        ResultErrorsListString = string.Join(", ", ResultErrorsList.ToArray());

                                        if (ResultErrorsListString != "")
                                        {
                                            ResultLine = "### ERROR ### [" + ResultErrorsListString + "]";
                                            Results.AppendText(ResultLine + Environment.NewLine);
                                            ProcessTotalErrors++;
                                        }
                                        else
                                        {
                                            ResultScore = JSONObject["documents"][0]["score"].ToString();

                                            ResultLine = "Sentence Sentiment [" + ResultScore + "]";
                                            Results.AppendText(ResultLine + Environment.NewLine);

                                            //Write to File
                                            FileLine = SentimentID.ToString() + "\t" + SentenceID.ToString() + "\t" + Sentence + "\t" + ResultScore;
                                            streamWriter_Sentence.WriteLine(FileLine);
                                        }
                                        SentenceID++;
                                    }
                                }
                            }
                        }
                        else // blank line in file
                        {
                            //Write BLANK to File
                            FileLine = SentimentID.ToString() + "\t" + "" + "\t" + "";
                            streamWriter_Sentiment.WriteLine(FileLine);
                        }

                        SentimentID++;
                        Results.AppendText(Environment.NewLine);
                        ProgressBar.Value = ProgressBar.Value + ProgressIncAmt;
                        PctComplete.Text = ProgressBar.Value.ToString() + "%";
                    }
                    file.Close();
                }

            // Increase Progress Bar
            ProgressBar.Value = ProgressBar.Value + ProgressIncAmt;
            PctComplete.Text = ProgressBar.Value.ToString() + "%";

            // Close Output Files
            streamWriter_Sentiment.Close();
            streamWriter_Sentence.Close();
            streamWriter_Phrases.Close();

            Results.AppendText(Environment.NewLine);
            Results.AppendText("Write Sentiment File [" + FileName_Sentiment + "]." + Environment.NewLine);
            Results.AppendText(Environment.NewLine);
            Results.AppendText("Write Sentence File [" + FileName_Sentence + "]." + Environment.NewLine);
            Results.AppendText(Environment.NewLine);
            Results.AppendText("Write Key Phrases File [" + FileName_Phrases + "]." + Environment.NewLine);

            // Set progress to 100%
            Results.AppendText(Environment.NewLine);
            Results.AppendText("Process Completed. [" + SentimentID.ToString() + "] Text Lines Processed. [" + ProcessTotalErrors.ToString() + "] Errors." + Environment.NewLine);
            ProgressBar.Value = 100;
            PctComplete.Text = ProgressBar.Value.ToString() + "%";

            }
            catch (Exception ex)
            {
                MessageBox.Show("A processing error occured." + "\n" + "Last Error Message: " + ex.Message + "\n" + "Last API Response: " + JSONCallResponse.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Process.Enabled = true;
            //System.Diagnostics.Process.Start("explorer.exe", OutputFile.Text);
        }

        static async Task<String> CallEndpoint(HttpClient client, string uri, byte[] byteData)
        {
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var JSONCallResponse = await client.PostAsync(uri, content);
                return await JSONCallResponse.Content.ReadAsStringAsync();
            }
        }

        private void OpenSourceFile_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                SourceFile.Text = file;
            }
            //Console.WriteLine(result); // <-- For debugging use.
        }

        private void SelectOutputFolder_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string path = folderBrowserDialog1.SelectedPath;
                OutputFile.Text = path;
            }
            //Console.WriteLine(result); // <-- For debugging use.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            APIKey.Text = Clipboard.GetText();
        }

        private void CloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void cbReplaceTab_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTAB.Enabled == true)
                cbTAB.Enabled = false;
            else
                cbTAB.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbTAB.SelectedIndex = 0;
        }

        static string Truncate(string source, int length)
        {
            for (Int32 i = source.Length - 1; i >= 0; i--)
            {
                if (System.Text.ASCIIEncoding.Unicode.GetByteCount(source.Substring(0, i + 1)) <= length)
                {
                    return source.Substring(0, i + 1);
                }
            }

            return String.Empty;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void SourceFile_TextChanged(object sender, EventArgs e)
        {
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
        }

    }
}
