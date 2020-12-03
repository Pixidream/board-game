// using
using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;


// namespace
namespace board_game {
    // class
    class Agent {
        private static Agent instance = null;
        private SpeechRecognizer recognizer;
        private SpeechSynthesizer synthesizer;
        public delegate void onSpeechHandler(string text);
        public onSpeechHandler onSpeech;

        private Agent() {}

        private Agent(String apiKey, String apiLocation) {
            SpeechConfig config = SpeechConfig.FromSubscription(apiKey, apiLocation);
            config.SpeechSynthesisLanguage = "fr-FR";
            config.SpeechRecognitionLanguage = "f-FR";
            recognizer = new SpeechRecognizer(config);
            recognizer.Recognized += RecognisedEventHandler;
            synthesizer = new SpeechSynthesizer(config);
        }

        public static Agent getInstance(String apiKey, String apiLocation) {
            if (instance == null) {
                instance = new Agent(apiKey, apiLocation);
            }
            return instance;
        }

        public void startListening() {
            Console.WriteLine("Agent is listening ...");
            recognizer.StartContinuousRecognitionAsync();
        }

        public async Task stopListening() {
            await recognizer.StopContinuousRecognitionAsync();
        }

        private void RecognisedEventHandler(object sender, SpeechRecognitionEventArgs e) {
            if (!string.IsNullOrEmpty(e.Result.Text)) onSpeech(e.Result.Text);
        }

        public async Task SynthesisToSpeackerAsync (String text) {
            await synthesizer.SpeakTextAsync(text);
        }
    }
}