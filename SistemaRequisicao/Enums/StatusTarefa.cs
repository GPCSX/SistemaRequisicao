﻿using System.ComponentModel;

namespace SistemaRequisicao.Enums
{
    public enum StatusTarefa
    {
        [Description("A Fazer")]
        Afazer = 1,
        [Description("Em Andamento")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3,
    }
}
