using DS2_Projekt.Models;
using Oracle.ManagedDataAccess.Client;

namespace DS2_Projekt.DAO;

public class VisitDAO {
    private static string SqlUpdateTotalCost =
        "UPDATE visit SET total_cost = :v_total_cost " +
        "WHERE visit_id = :v_visit_id";

    public static bool UpdateVisitCost(Database pDb, int visitId, int totalCost) {
        Database db = Database.Connect(pDb);
        bool success = false;

        OracleCommand command = db.CreateCommand(SqlUpdateTotalCost);
        command.BindByName = true;
        command.Parameters.Add(":v_visit_id", visitId);
        command.Parameters.Add(":v_total_cost", totalCost);

        int rowsAffected = db.ExecuteNonQuery(command);
        success = rowsAffected > 0;

        return success;
    }
}