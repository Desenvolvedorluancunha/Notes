using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Notes.Models;
using System;

namespace Notes.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection database;

        public NoteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Note>().Wait();
            database.CreateTableAsync<Usuario>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            //Get all notes.
            return database.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            // Get a specific note.
            return database.Table<Note>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(note);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(note);
            }
        }

        public Task<int> SaveLogin(Usuario usuario)
        {
            if (usuario.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(usuario);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(usuario);
            }
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }

        public Task<Usuario> GeUsuarioAsync(Usuario usuario)
        {
            // Get a specific note.
            var retorno = database.Table<Usuario>()
                            .Where(i => i.NOME_USUARIO == usuario.NOME_USUARIO)
                            .FirstOrDefaultAsync();

            return retorno;
        }

        public Task<int> SaveUsuarioAsync(Usuario usuario)
        {
            try
            {
                if (usuario.ID != 0)
                {
                    // Update an existing note.
                    return database.UpdateAsync(usuario);
                }
                else
                {
                    // Save a new note.
                    return database.InsertAsync(usuario);
                }
            }
            catch (Exception EX)
            {

                return null;
            }
        }
    }
}