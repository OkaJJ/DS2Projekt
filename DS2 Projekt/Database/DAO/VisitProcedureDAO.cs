using DS2_Projekt.Models;
using Oracle.ManagedDataAccess.Client;

namespace DS2_Projekt.DAO;

public class VisitProcedureDAO {
    private static string SqlSelect =
        "SELECT visit_id, procedure_id, quantity FROM visit_procedure " +
        "WHERE visit_id = :visit_id AND procedure_id = :procedure_id";

    public static VisitProcedure? Select(Database pDb, int visitId, int procedureId) {
        Database db = Database.Connect(pDb);
        VisitProcedure? visitProcedure = null;

        OracleCommand command = db.CreateCommand(SqlSelect);
        command.BindByName = true;
        command.Parameters.Add(":visit_id", visitId);
        command.Parameters.Add(":procedure_id", procedureId);

        var reader = db.Select(command);
        if (reader.Read()) {
            visitProcedure = new VisitProcedure {
                visit_id = reader.GetInt32(0), procedure_id = reader.GetInt32(1), quantity = reader.GetInt32(2)
            };
        }

        reader.Close();

        return visitProcedure;
    }

    private static string SqlUpdateQuantity =
        "UPDATE visit_procedure SET quantity = quantity + :add_quantity " +
        "WHERE visit_id = :visit_id AND procedure_id = :procedure_id";

    public static bool UpdateProcedureQuantity(Database pDb, int visitId, int procedureId, int addQuantity) {
        Database db = Database.Connect(pDb);
        bool success = false;

        OracleCommand command = db.CreateCommand(SqlUpdateQuantity);
        command.BindByName = true;
        command.Parameters.Add(":visit_id", visitId);
        command.Parameters.Add(":procedure_id", procedureId);
        command.Parameters.Add(":add_quantity", addQuantity);

        int rowsAffected = db.ExecuteNonQuery(command);
        success = rowsAffected > 0;

        return success;
    }

    private static string SqlInsert =
        "INSERT INTO visit_procedure (visit_id, procedure_id, quantity) " +
        "VALUES (:visit_id, :procedure_id, :quantity)";

    public static bool Insert(Database pDb, VisitProcedure visitProcedure) {
        Database db = Database.Connect(pDb);
        bool success = false;

        OracleCommand command = db.CreateCommand(SqlInsert);
        command.BindByName = true;
        command.Parameters.Add(":visit_id", visitProcedure.visit_id);
        command.Parameters.Add(":procedure_id", visitProcedure.procedure_id);
        command.Parameters.Add(":quantity", visitProcedure.quantity);

        int rowsAffected = db.ExecuteNonQuery(command);
        success = rowsAffected > 0;

        return success;
    }
}