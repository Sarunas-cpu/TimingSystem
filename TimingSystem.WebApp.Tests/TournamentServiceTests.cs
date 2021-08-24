//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TimingSystem.WebApp.Database;
//using TimingSystem.WebApp.Database.Entities;

//namespace TimingSystem.WebApp.Tests
//{
//    [TestClass]
//    public class TournamentServiceTests
//    {
//        private DatabaseContext dbContext;

//        [TestInitialize()]
//        public void Startup()
//        {
//            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("TournamentDB").Options;

//            dbContext = new DatabaseContext(options);

//            dbContext.Tournaments.Add(new Tournament { TournamentId = 399, 
//                                                       ParticipantFirstName = "Stepas", 
//                                                       ParticipantLastName = "Brrrrr", 
//                                                       Category = "Very Fast"});

//        }

//        [TestMethod]
//        public void GetData_WhenParametersNotProvided()
//        {
//            // Setup
//            var
//            Moq.IMock<>
//            // ack

//            //assert
//            Assert.IsNotNull();
//        }


//    }
//}
