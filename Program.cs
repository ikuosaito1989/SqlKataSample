using System;
using System.Linq;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data.SqlClient;

namespace SqlKataSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection("");
            var compiler = new SqlServerCompiler();
            var db = new QueryFactory();
            var query = db.Query(nameof(Hoge))
                .Join(nameof(Piyo), "Hoge.PiyoId", "Piyo.Id")
                .OrderBy("Hoge.Id");
            var sql = compiler.Compile(query).Sql;
        }
    }
    public class Hoge {
        public int Id { get; set; }
        public int PiyoId { get; set; }
    }

    public class Piyo {
        public int Id { get; set; }
    }
    
}
