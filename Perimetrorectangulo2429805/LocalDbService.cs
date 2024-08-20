using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perimetrorectangulo2429805
{
    public class LocalDbService
    {
        private const string DB_NAME = "rectangulo_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Rectangulo>().Wait();
        }

        public async Task<List<Rectangulo>> GetRectangulos()
        {
            return await _connection.Table<Rectangulo>().ToListAsync();
        }

        public async Task<Rectangulo> GetById(int id)
        {
            return await _connection.Table<Rectangulo>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Rectangulo rectangulo)
        {
            await _connection.InsertAsync(rectangulo);
        }

        public async Task Update(Rectangulo rectangulo)
        {
            await _connection.UpdateAsync(rectangulo);
        }

        public async Task Delete(Rectangulo rectangulo)
        {
            await _connection.DeleteAsync(rectangulo);
        }
    }
}
