﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class test_1_4
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

    [SetUp]
    public void SetupTest()
    {
        driver = new FirefoxDriver();
        baseURL = "https://www.google.com/";
        verificationErrors = new StringBuilder();
    }

    [TearDown]
    public void TeardownTest()
    {
        try
        {
            driver.Quit();
        }
        catch (Exception)
        {
            // Ignore errors if unable to close the browser
        }
        Assert.AreEqual("", verificationErrors.ToString());
    }

    [Test]
    public void The14Test()
    {
        driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
        driver.FindElement(By.LinkText("COMPUTERS")).Click();
        driver.FindElement(By.LinkText("Desktops")).Click();
        driver.FindElement(By.LinkText("Build your own cheap computer")).Click();
        driver.FindElement(By.Id("add-to-cart-button-72")).Click();
        driver.FindElement(By.LinkText("Desktops")).Click();
        driver.FindElement(By.LinkText("Build your own expensive computer")).Click();
        driver.FindElement(By.Id("add-to-cart-button-74")).Click();
        driver.FindElement(By.XPath("//li[@id='topcartlink']/a/span")).Click();
        driver.FindElement(By.Name("removefromcart")).Click();
        driver.FindElement(By.XPath("(//input[@name='removefromcart'])[2]")).Click();
        driver.FindElement(By.Name("updatecart")).Click();
    }
    private bool IsElementPresent(By by)
    {
        try
        {
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    private bool IsAlertPresent()
    {
        try
        {
            driver.SwitchTo().Alert();
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }

    private string CloseAlertAndGetItsText()
    {
        try
        {
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            if (acceptNextAlert)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
            return alertText;
        }
        finally
        {
            acceptNextAlert = true;
        }
    }
}
}
