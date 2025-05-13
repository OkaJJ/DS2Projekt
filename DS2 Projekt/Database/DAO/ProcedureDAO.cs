using DS2_Projekt.Models;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace DS2_Projekt.DAO;

public class ProcedureDAO {
    private static string SqlSelect =
        "SELECT procedure_id, name, code, price FROM procedure WHERE procedure_id = :procedure_id";

    public static Procedure? Select(Database pDb, int procedure_id) {
        Database db = Database.Connect(pDb);
        Procedure? procedure = null;

        OracleCommand command = db.CreateCommand(SqlSelect);
        command.BindByName = true;
        command.Parameters.Add(":procedure_id", procedure_id);

        var reader = db.Select(command);

        if (reader.Read()) {
            procedure = new Procedure {
                procedure_id = reader.GetInt32(0),
                name = reader.GetString(1),
                code = reader.GetString(2),
                price = reader.GetInt32(3)
            };
        }

        reader.Close();

        return procedure;
    }
}