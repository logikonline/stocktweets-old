﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock_Scouter.Models
{
    class Stock
    {
        private string _symbol;
        public string Symbol {
            get { return this._symbol; }
            set { this._symbol = value; }
        }
        
        private string _name;
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private double _askPrice = 0.0;
        public double AskPrice
        {
            get { return this._askPrice; }
            set { this._askPrice = value; }
        }

        private double _bidPrice = 0.0;
        public double BidPrice
        {
            get { return this._bidPrice; }
            set { this._bidPrice = value; }
        }

        private double _lastTradePrice = 0.0;
        public double LastTradePrice
        {
            get { return this._lastTradePrice; }
            set { this._lastTradePrice = value; }
        }

        private string _lastTradeDate;
        public string LastTradeDate
        {
            get { return this._lastTradeDate; }
            set { this._lastTradeDate = value; }
        }

        private double _openPrice = 0.0;
        public double OpenPrice
        {
            get { return this._openPrice; }
            set { this._openPrice = value; }
        }

        private double _dayHighPrice = 0.0;
        public double DayHighPrice
        {
            get { return this._dayHighPrice; }
            set { this._dayHighPrice = value; }
        }

        private double _dayLowPrice = 0.0;
        public double DayLowPrice
        {
            get { return this._dayLowPrice; }
            set { this._dayLowPrice = value; }
        }

        private int _volume = 0;
        public int Volume
        {
            get { return this._volume; }
            set { this._volume = value; }
        }

        private string _weekRange;
        public string WeekRange
        {
            get { return this._weekRange; }
            set { this._weekRange = value; }
        }

        private string _dayRange;
        public string DayRange
        {
            get { return this._dayRange; }
            set { this._dayRange = value; }
        }

        private string _dividend;
        public string Dividend
        {
            get { return this._dividend; }
            set { this._dividend = value; }
        }

        private string _dividendYield;
        public string DividendYield
        {
            get { return this._dividendYield; }
            set { this._dividendYield = value; }
        }

        private string _peRatio;
        public string PERatio
        {
            get { return this._peRatio; }
            set { this._peRatio = value; }
        }

        public Stock(string csv) {
            //"XOM","Exxon Mobil Corpo","4/17/2014",100.42,99.69,100.97,99.69,15439810,"84.79 - 101.74",2.52,2.52,13.56
            string[] items = csv.Split(',');
            this.Symbol = items[0];
            this.Name = items[1];
            this.LastTradeDate = items[2];
            this.LastTradePrice = Convert.ToDouble(items[3]);
            this.OpenPrice = Convert.ToDouble(items[4]);
            this.DayHighPrice = Convert.ToDouble(items[5]);
            this.DayLowPrice = Convert.ToDouble(items[6]);
            this.Volume = Convert.ToInt32(items[7]);
            this.DayRange = items[8];
            this.Dividend = items[9];
            this.DividendYield = items[10];
            this.PERatio = items[11];
        }



    }
}
