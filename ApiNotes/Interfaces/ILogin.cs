﻿using ApiNotes.Entities;

namespace ApiNotes.Interfaces
{
    public interface ILogin : ICrud<Login>
    {
        public IEnumerable<Login> ConsultarLoginPorUsuario(int id);
    }
}
