export interface Cliente {
    id: number
    nome: string
    telefone: string
    email?: string
    dataCadastro?: string
}

// Tipo usado só para criar — sem id nem dataCadastro (o backend gera isso)
export type NovoCliente = Pick<Cliente, 'nome' | 'telefone' | 'email'>