using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovilEmpleo
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
