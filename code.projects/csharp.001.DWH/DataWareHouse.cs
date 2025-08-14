using System;
using System.Collections;
using System.Collections.Generic;

namespace Statistics.com.business
{
    internal class DataWareHouse
    {
        private ArrayList Items;
        private Int32 index;
        private String message;
        private Boolean error;

        DataWareHouse()
        {
            this.Items = new ArrayList();
            this.index = 0;
            this.message = String.Empty;
            this.error = false;
        }

        public void add(double value)
        {
            try
            {
                this.Items.Add(value);
            }
            catch (Exception exception)
            {
                this.message = exception.Message;
                this.error = true;
            }
        }

        public double GetItems(Int32 position)
        {
            try
            {
                return (double)this.Items[position];
            }
            catch (Exception ex)
            {
                this.message = ex.Message;
                this.error = true;
            }
            return -1;
        }

        public ArrayList GetItems()
        {
            return this.Items;
        }

        public void ClearItems()
        {
            this.Items.Clear();
        }

        public String GetError()
        {
            return this.message;
        }

        public Boolean isExist()
        {
            return this.error;
        }
    }
}