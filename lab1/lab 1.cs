[TestClass]
    public class lab1 : UnitTest1
    {
        
        public lab1() : base("MyMVCApp") { }

        [TestMethod]
        public void IndexChromeTest()
        {
			//Apelez metoda void utilizand ChromeDriver din clasa parinte.
            IndexTestByDriver(this.ChromeDriver);
        }

        private void IndexTestByDriver(IWebDriver driver)
        {
            // Navig spre pagina https://localhost:57931/Home/Index 
			//                        pagina initiala in proiect
            driver.Navigate().GoToUrl(this.GetAbsoluteUrl("/home/index"));
			
			//Caut elementul cu id-ul "loginLink" si invoc evenimentul Click
            driver.FindElement(By.Id("loginLink")).Click();
			
			// Stochez locatia elementului cu id-ul "Login" in variabila emailTextBox
            var loginTextBox = driver.FindElement(By.Id("Login"));
			
			// Invoc evenimentul Click pentru Textbox
            loginTextBox.Click();
			
			// Adaug login
            loginTextBox.SendKeys("emoName@gmail.com");

			// Stochez locatia elementului cu id-ul "Password" in variabila passwd
            var passwd = driver.FindElement(By.Id("Password"));
			
			// Invoc evenimentul Click pentru Textbox
            passwd.Click();
			
			//Adaug password
            passwd.SendKeys("emoName");

			//Caut elementul cu clasa "btn-default" si invoc evenimentul Click
            driver.FindElement(By.ClassName("btn-default")).Click();

            // In caz ca a fost redirectionat spre pagina home/index  sau https://localhost:49869/
			//  		Testul a fost rulat cu success, in caz contrar nu
            Assert.IsTrue(driver.Url.Equals(this.GetAbsoluteUrl("")));

        }
    }