package test;

import org.junit.jupiter.api.Test;
import org.openqa.selenium.*;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.ExpectedCondition;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.io.File;
import java.io.PrintStream;
import java.util.concurrent.TimeUnit;

public class Scrapping {
    @Test
    public void startWebDriver() throws InterruptedException {
        // TODO Auto-generated method stub
        String page_number;

        System.setProperty("webdriver.chrome.driver","D:\\SeleniumDrivers\\chromedriver.exe");

        WebDriver driver = new ChromeDriver();
        driver.get("https://www.ebay.de/");
        driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
        driver.findElement(By.id("gh-ac")).sendKeys("Mens Boots" + Keys.ENTER);
        Thread.sleep(2000);

        for(int i =0; i<5; i++){
            driver.findElement(By.xpath("//*[@id=\"Pagination\"]/tbody/tr/td[3]/a")).click();
        }


    }
}
