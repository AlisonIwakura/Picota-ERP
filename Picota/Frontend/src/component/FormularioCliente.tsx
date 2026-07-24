import { useState } from 'react'
import api from '../Services/api'
import type { NovoCliente } from '../types/Cliente'

function FormularioCliente() {
    const [nome, setNome] = useState('')
    const [telefone, setTelefone] = useState('')
    const [email, setEmail] = useState('')
    const [enviando, setEnviando] = useState(false)
    const [mensagem, setMensagem] = useState('')

    async function handleSubmit(e: React.FormEvent) {
        e.preventDefault()
        setEnviando(true)
        setMensagem('')

        const novoCliente: NovoCliente = { nome, telefone, email }

        try {
            await api.post('/Clientes', novoCliente)
            setMensagem('Cliente cadastrado com sucesso!')
            setNome('')
            setTelefone('')
            setEmail('')
        } catch (err) {
            console.error(err)
            setMensagem('Erro ao cadastrar cliente.')
        } finally {
            setEnviando(false)
        }
    }

    return (
        <form onSubmit= { handleSubmit } >
        <h2>Novo Cliente </h2>

            < div >
            <label>Nome </label>
            < input
    type = "text"
    value = { nome }
    onChange = { e => setNome(e.target.value) }
    required
        />
        </div>

        < div >
        <label>Telefone </label>
        < input
    type = "text"
    value = { telefone }
    onChange = { e => setTelefone(e.target.value) }
    required
        />
        </div>

        < div >
        <label>Email(opcional) </label>
        < input
    type = "email"
    value = { email }
    onChange = { e => setEmail(e.target.value) }
        />
        </div>

        < button type = "submit" disabled = { enviando } >
        { enviando? 'Enviando...': 'Cadastrar' }
            </button>

    { mensagem && <p>{ mensagem } </p> }
    </form>
  )
}

export default FormularioCliente