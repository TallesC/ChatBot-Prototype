namespace Bot.Tests
{
    [TestClass]
    public class FlowTests
    {
        [TestMethod]
        public void ProcessMessage_GivenAValidInputAtStart_ShouldReturnCorrectOutput()
        {
            // arrange
            var chatbot = new ChatBot();
            string input = "oi";

            // act
            var returnValue = chatbot.ProcessMessage(input);

            // assert
            Assert.AreEqual("Oi!", returnValue);
        }

        [TestMethod]
        public void ProcessMessage_GivenAnEmptyString_ShouldThrowAnArgumentException()
        {
            // arrange
            var chatbot = new ChatBot();
            string input = "";

            // act
            Exception? exception = null;
            try
            {
                var returnValue = chatbot.ProcessMessage(input);
            }
            catch(Exception ex)
            {
                exception = ex;
            }

            // assert
            Assert.IsInstanceOfType(exception, typeof(ArgumentException));
        }

        [TestMethod]
        
        public void ProcessMessage_GivenAWelcomeMessage_ShouldReturnCorrectNextFlow()
        {

            //arrange
            var chatbot = new ChatBot();
            string firstInput = "Inicio";
            string input = "Olá";
            chatbot.ProcessMessage(firstInput);

            //act
            var returnValue = chatbot.ProcessMessage(input);

            //assert
            Assert.AreEqual("Escolha 1,2,3", returnValue);
        }
    }
}