

function ActiveObj({ Tipo, Placa, Marca, onDelete }) {
    function onDeleteHandler() {
        onDelete(Placa)
    }

    return <>
        <li>
            <div>
                <p>Tipo: {Tipo}</p>
                <p>Placa: {Placa}</p>
                <p>Marca: {Marca}</p>
            </div>
            <button onClick={onDeleteHandler}>Seleccionar</button>
        </li>
    </>
}

export default ActiveObj;