﻿namespace Models
{
    public class Permissao
    {
        public string Descricao { get; set; }
        public int Id { get; set; }
        public List<GrupoUsuario> GrupoUsuarios { get; set; }
    }
}
