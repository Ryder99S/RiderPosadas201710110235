using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExamenTercerParcial.Modelos;
using SQLite;

namespace ExamenTercerParcial.Database
{
    public class SQLitebsd
    {
        SQLiteAsyncConnection db;
        public SQLitebsd(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Pagos>().Wait();
        }

        public Task<int> GuardarPago(Pagos pago)
        {
            if (pago.Id_pago != 0)
            {
                return db.UpdateAsync(pago);
                ;
            }
            else
            {
                return db.InsertAsync(pago);
            }
        }

        public Task<List<Pagos>> GetPagoAync()
        {
            return db.Table<Pagos>().ToListAsync();
        }

        public Task<Pagos> GetPagoByIdAsync(int pago)
        {
            return db.Table<Pagos>().Where(a => a.Id_pago == pago).FirstOrDefaultAsync();
        }

        public Task<int> GrabarPago(Pagos pago)
        {
            if (pago.Id_pago != 0)
            {
                return db.UpdateAsync(pago);
            }
            else
            {
                return db.InsertAsync(pago);
            }
        }

        public Task<int> DropPagosAsync(Pagos pago)
        {
            return db.DeleteAsync(pago);
        }

    }
}
