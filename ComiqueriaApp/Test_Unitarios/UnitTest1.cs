using System;
using System.IO;
using ComiqueriaLogic;
using ComiqueriaLogic.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string path = "binPrueba.bin";

            Comiqueria c = new Comiqueria();
            Serializador<Comiqueria>.EscribirBinario(path, c);

            Assert.IsTrue(File.Exists(path));
            if(File.Exists(path))
            {
                File.Delete(path);
            }
            
            
        }
    }
}
