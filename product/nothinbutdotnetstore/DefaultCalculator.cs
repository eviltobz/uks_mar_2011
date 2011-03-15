using System;
using System.Data;
using System.Security;
using System.Threading;

namespace nothinbutdotnetstore
{
    public class DefaultCalculator : Calculator
    {
        IDbConnection connection;

        public DefaultCalculator(IDbConnection connection,int number,int number2)
        {
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            ensure_numbers_are_positive(first,second);
            connection.Open();
            connection.CreateCommand().ExecuteNonQuery();
            return first + second;
        }

        void ensure_numbers_are_positive(int first, int second)
        {
            if (first > 0 && second > 0) return;
            throw new ArgumentException();
        }

        public void shut_down()
        {
            if (Thread.CurrentPrincipal.IsInRole("blah")) return;

            throw new SecurityException();
        }
    }
}