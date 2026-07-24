import { useState, useEffect } from 'react'
import api from '../Services/api'
import type { Cliente } from '../types/Cliente'

function ListaClientes() {
    const [clientes, setClientes] = useState<Cliente[]>([])
    const [carregando, setCarregando] = useState(true)
    const [erro, setErro] = useState('')

    useEffect(() => {

        api.get<Cliente[]>('/Clientes')
            .then(response => {
                setClientes(response.data)
            })
            .catch(err => {
                console.error(err)
                setErro('Não foi possível carregar os clientes.')
            })
            .finally(() => {
                setCarregando(false)
            })
    }, [])

    if (carregando) return <p>Carregando clientes...</p>
    if (erro) return <p>{ erro } </p>

    return (
        <div>
        <h2>Clientes </h2>
        <ul>
        {
        clientes.map(cliente => (
            <li key= { cliente.id } >
            { cliente.nome } — { cliente.telefone }
        </li>
        ))
    }
    </ul>
        </div>
  )
}

export default ListaClientes