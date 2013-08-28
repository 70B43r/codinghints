//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Testsetup.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using NUnit.Framework;
using log4net;
using log4net.Appender;
using log4net.Layout;

namespace tobaer.CSharp.codinghints.XmlRpc
{
   [SetUpFixture]
   public class TestSetup
   {
      private static readonly ILog Log = LogManager.GetLogger(typeof(TestSetup));

      public TestSetup()
      {
         if (!LogManager.GetRepository().Configured)
         {
            log4net.Config.BasicConfigurator.Configure(new ConsoleAppender
                                                       {
                                                          Layout = new PatternLayout("%logger{2} - %message%newline")
                                                       });
            Log.Debug("Configured");
         }
      }
   }
}