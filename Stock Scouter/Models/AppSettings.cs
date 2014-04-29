﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;
using Stock_Scouter.Models;

namespace Stock_Scouter.Models
{
    /**
     * A static class that abstracts the internal storage of the app
     * */
    class AppSettings
    {
        private static IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        private static int AUTO_REFRESH_INTERVAL = 5; // in seconds

        public static int AutoRefreshInterval
        {
            get
            {
                return findKey("AutoRefreshInterval", AUTO_REFRESH_INTERVAL);
            }
            set
            {
                setKey("AutoRefreshInterval", value);
            }
        }

        public static List<string> GetPortfolioList()
        {
            if (settings.Contains("PortfolioList") && ((List<string>)settings["PortfolioList"]).Count() > 0)
            {
                return (List<string>)settings["PortfolioList"];
            }
            else
            {
                Portfolio p = GetPortfolio("Default");
                List<string> pl = new List<string>();
                pl.Add("My Watchlist");
                deleteKey("PortfolioList");
                settings.Add("PortfolioList", pl);
                return pl;
            }
        }

        public static void addPortfolio(Portfolio p)
        {
            GetPortfolioList().Add(p.Name);
            System.Diagnostics.Debug.WriteLine("Added portfolio " + p.Name + " to list.");
        }

        public static bool isPortfolioExist(string key)
        {
            return settings.Contains("P_" + key);
        }

        public static Portfolio GetPortfolio(string key)
        {
            if (settings.Contains("P_" + key)) return (Portfolio)settings["P_" + key];
            Portfolio p = new Portfolio() {Name = key};
            settings.Add("P_" + key, p);
            System.Diagnostics.Debug.WriteLine("Portfolio " + key + " not found. Created it.");
            return p;
        }

        public static void SetPortfolio(string key, Portfolio p)
        {
            if (!settings.Contains("P_" + key))
            {
                settings.Add("P_" + key, p);
            }
            else
            {
                settings["P_" + key] = p; // what if user creates a new portfolio?
            }
        }

        public static void DeletePortfolio(string key)
        {
            if (settings.Contains("P_" + key))
            {
                settings.Remove("P_" + key);
                List<string> portfolioList = GetPortfolioList();
                if (portfolioList.Contains(key))
                {
                    portfolioList.Remove(key);
                    settings["PortfolioList"] = portfolioList;
                }
            }
        }

        public static Quote GetStock(string key)
        {
            if (!settings.Contains("Q_" + key)) throw new NullReferenceException("The stock symbol \"" + key + "\" was not in the database.");
            return (Quote)settings["Q_" + key];
        }

        public static void SetQuote(string key, Quote q)
        {
            if (!settings.Contains("Q_" + key))
            {
                settings.Add("Q_" + key, q);
            }
            else
            {
                settings["Q_" + key] = q;
            }
        }

        public static void DeleteStock(string key)
        {
            if (settings.Contains("S_" + key)) settings.Remove("S_" + key);
        }

        public static void deleteKey(string symbol)
        {
            if (settings.Contains(symbol))
                settings.Remove(symbol);
        }

        private static int findKey(string key, int defaultValue)
        {
            if (settings.Contains(key)) return (int)settings[key];
            settings.Add(key, defaultValue);
            return defaultValue;
        }

        private static double findKey(string key, double defaultValue)
        {
            if (settings.Contains(key)) return (double)settings[key];
            settings.Add(key, defaultValue);
            return defaultValue;
        }

        private static string findKey(string key, string defaultValue)
        {
            if (settings.Contains(key)) return (string)settings[key];
            settings.Add(key, defaultValue);
            return defaultValue;
        }

        private static void setKey(string key, int value)
        {
            settings[key] = value;
        }

        private static void setKey(string key, double value)
        {
            settings[key] = value;
        }

        private static void setKey(string key, string value)
        {
            settings[key] = value;
        }

    }
}
