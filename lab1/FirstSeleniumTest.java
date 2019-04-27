package test;

import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

public class FirstSeleniumTest {

    @Test
    public void startWebDriver() throws InterruptedException {


        System.setProperty("webdriver.chrome.driver", "D:\\SeleniumDrivers\\chromedriver.exe");

        WebDriver driver = new ChromeDriver();

        driver.get("file:///C:/Users/Zaharia%20Gabriel/Desktop/WebPage/index.html?");
        driver.findElement(By.name("firstname")).sendKeys("username");
        driver.findElement(By.name("lastname")).sendKeys("password");
        driver.findElement(By.xpath("/html/body/form/input[3]")).click();

        if (driver.getTitle().equals("Login")) {
            System.out.println("Test passed");
        }
        Thread.sleep(2000);


        //  driver.close();

    }

}