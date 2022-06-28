using NUnit.Framework;
using ProjektZaliczeniowy;
using System;

namespace TestProject
{
    /// <summary>
    ///Test jednostkowy dla wybranych metod
    /// </summary>
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test jednostkowy dla pola dotycz¹cego d³ugoœci stringa odpowiadaj¹cego za surname oraz komunikat przechwytywanego wyj¹tku.
        /// </summary>
        [Test]
        public void Test1Doctor()
        {
            Assert.DoesNotThrow(() => new Doctor { Id = 2, NameSurname = "Zofia Kowalski", Adress = " Zielona 5", PermissionNumber = " 560053", RoleId = 3, SpecializationId = 2 });
            Assert.Catch(() => new Doctor { Id = 2, NameSurname = " ", Adress = " Zielona 5", PermissionNumber = " 560053", RoleId = 3, SpecializationId = 2 });
            var exception = Assert.Throws<ArgumentException>(
            () => new Doctor { Id = 2, NameSurname = " ", Adress = " Zielona 5", PermissionNumber = " 560053", RoleId = 3, SpecializationId = 2 });
            Assert.AreEqual("B³êdne dane", exception.Message);
        }

        /// <summary>
        /// Test jednostkowy dla pola dotycz¹cego d³ugoœci wartosci wprowadzonej w polu pesel.
        /// </summary>

        [Test]
        public void Test2Patient()
        {
            Assert.DoesNotThrow(() => new Patient { Id = 2, Name = "Zofia Adam", Adress = " Ostoja 5", Pesel = 78020607221, RoleId = 2 });
            Assert.Catch(() => new Patient { Id = 2, Name = "Zdzis³aw S³owik", Adress = " Ostoja 5", Pesel = 7, RoleId = 2 });
            Assert.Catch(() => new Patient { Id = 2, Name = "Marek Szos", Adress = " Ostoja 5", Pesel = 0, RoleId = 2 });
            var exception = Assert.Throws<ArgumentException>(
            () => new Patient { Id = 2, Name = "Marek Szos", Adress = " Ostoja 5", Pesel = 0, RoleId = 2 });
            Assert.AreEqual("B³êdne dane", exception.Message);
        }
    }
}