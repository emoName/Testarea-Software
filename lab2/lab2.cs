{
    [TestClass]
    public class Lab2 :UnitTest1
    {
        public Lab2() : base("MyMVCApp") { }

        [TestMethod]
        public void IndexChromeTest()
        {
            IndexTestByDriver(this.ChromeDriver);
        }

        private void IndexTestByDriver(IWebDriver driver)
        {
			// Utilizez try catch in cazul cand un element nu a fost gasit el automat trece spre catch si opreste testul
            try
            {
				// Aici se vor pastra produsele resultante
                var result = new List<Card>();
                // Accesez site-ul http://maxmart.md/ro/
                driver.Navigate().GoToUrl("http://maxmart.md/ro/");
				
				//Caut elementul "Gadgeturi" din bara de meniu folosind xPath si invoc evenimentul Click
                driver.FindElement(By.XPath("/html/body/header/nav/table/tbody/tr/td[1]/span")).Click();
				
				//Nr de pagini accesate
                int count = 0;
				
				
				
				// Atita timp cat butonul "next page" nu are clasa disabled sa ruleze codul de mai jos
                while (!HasClass(driver.FindElement(By.XPath("/html/body/div[1]/section/footer/div[2]/a[2]")), "disabled"))
                {
					// In caz ca pagina accesata egala cu pagina total dorita
					// nu este obligatoriu
                    if (count == 2)
                    {
                        break;
                    }
					
					// Gasesc toate elementele care au classa card-item
                    var itemList = driver.FindElements(By.ClassName("card-item"));
					
					
                    foreach (var item in itemList)
                    {
						// Gasesc Containerul
                        var parent = item.FindElement(By.TagName("figcaption"));
						
						// Numele
                        var name = parent.FindElement(By.XPath(".//h3/a")).Text;
						
						// Pretul in string 
                        var price = parent.FindElement(By.XPath(".//button/span")).Text;
						
						//Descrierea
                        var description = parent.FindElement(By.TagName("em")).Text;

                        // Filtrez stringul aleg doar cifrele
                        var intList = Regex.Split(price, @"\D+");
						
						// Concatenez cifrele
                        var value = string.Join(string.Empty, intList);
						
						//In caz ca nu are pret
                        if (!value.Equals(string.Empty))
                        {
							// Parsing din string in int
                            var moneyCount = int.Parse(value);
							
							//Creez un obiect card cu datele urmatoare
                            var card = new Card
                            {
                                Name = name,
                                Price = moneyCount,
                                Description = description
                            };
							
							//Adaug in lista produselor resultante
                            result.Add(card);
                        }
                        else
                        {
                            continue;
                        }


                    }
					//Incrementez numarul de pagini accesate
                    count++;
					// Invoc evenimentul click la buttonul "next page"
                    driver.FindElement(By.XPath("/html/body/div[1]/section/footer/div[2]/a[2]")).Click();
                }

                Debug.WriteLine("Done");
				
				//Linq pentru a gasi cel mai mic price
                var minPrice = result.FirstOrDefault(x => x.Price.Equals(result.Min(m => m.Price)));
				//Printez la consola Debug Resultatul
                for (int i = 0; i < result.Count; i++)
                {
                    Debug.WriteLine($"#{i + 1}: {result[i].Name}   {result[i].Price} lei");
                    Debug.WriteLine($"Description: {result[i].Description}");
                    Debug.WriteLine($"______________________________");
                }
				// Printez cel mai mic price
                Debug.WriteLine($"Minimal Price: {minPrice.Name}   {minPrice.Price} lei");
				
				//Termin testul cu success
                Assert.IsTrue(true);
            }
            catch(Exception e)
            {
				//Termin testul cu esec
                Assert.IsTrue(false);
            }
            

        }

		// Functie pentru a gasi daca elementul dat contine o clasa anumita
        public static bool HasClass(IWebElement el, string className)
        {
            return el.GetAttribute("class").Split(' ').Contains(className);
        }

    }
    
}