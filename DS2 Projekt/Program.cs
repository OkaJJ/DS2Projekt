using System.Configuration;
using DS2_Projekt.DAO;
using DS2_Projekt.Models;

namespace DS2_Projekt;

class Program {
    static void Main(string[] args) {
        Database db = new Database();
        if (!db.Connect()) {
            Console.WriteLine("Nepodarilo se pripojit");
            return;
        }
        else {
            Console.WriteLine("Pripojeno k Oracle DB");
        }

        // PROVEDENI TRANSAKCE V KODU

        // Vstupni promenne
        int v_visit_id = 2;
        int v_procedure_id = 2;
        int v_procedure_quantity = 20;

        db.BeginTransaction();

        // Lokalni promenne
        int v_procedure_exists = 0;
        int v_procedure_cnt = 0;
        int v_procedure_cost = 0;

        try {
            var procedure = ProcedureDAO.Select(db, v_procedure_id);
            v_procedure_cost = procedure.price;

            var visit_procedure = VisitProcedureDAO.Select(db, v_visit_id, v_procedure_id);
            v_procedure_exists = (visit_procedure != null) ? 1 : 0;

            if (v_procedure_exists > 0) {
                VisitProcedureDAO.UpdateProcedureQuantity(db, v_visit_id, v_procedure_id, v_procedure_quantity);
            }
            else {
                var new_procedure = new VisitProcedure {
                    visit_id = v_visit_id,
                    procedure_id = v_procedure_id,
                    quantity = v_procedure_quantity
                };
                VisitProcedureDAO.Insert(db, new_procedure);
            }

            VisitDAO.UpdateVisitCost(db, v_visit_id, (v_procedure_cost * v_procedure_quantity));

            db.EndTransaction();

            Console.WriteLine("Transakce v kodu probehla");
        }
        catch {
            Console.WriteLine("Chyba pri provadeni transakce v kodu");
            db.Rollback();
            throw;
        }

        // PROVEDENI ULOZENOU PROCEDUROU

        // nefunguje EXEC :(
        string addProcedureSaved = "BEGIN AddProcedure(:v_visit_id, :v_procedure_id, :v_procedure_quantity); END;";

        var command = db.CreateCommand(addProcedureSaved);
        command.BindByName = true;
        command.Parameters.Add(":v_visit_id", v_visit_id);
        command.Parameters.Add(":v_procedure_id", v_procedure_id);
        command.Parameters.Add(":v_procedure_quantity", v_procedure_quantity);

        db.ExecuteNonQuery(command);
        
        Console.WriteLine("Ulozena procedura probehla");
        
        db.Close();
        
        Console.WriteLine("Vsechno je uzasne krasne funkcni, a ja davam C# navzdy sbohem, preji hezky den :)");
    }
}