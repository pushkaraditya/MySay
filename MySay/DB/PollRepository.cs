using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySay.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace MySay.DB
{
  public class PollRepository
  {
    private IDbConnection GetConnection()
    {
      return new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
    }

    public void Create(Poll poll)
    {
      var sql = "INSERT INTO Poll (Description, EndingOn) VALUES (@Description, @EndingOn)";

      var connection = GetConnection();
      connection.Execute(sql, poll);
    }

    public List<Poll> GetPolls()
    {
      var sql = "SELECT * FROM Poll";

      var connection = GetConnection();
      return connection.Query<Poll>(sql).ToList();
    }
  }
}