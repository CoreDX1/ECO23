import Usuario from "./Usuarios.json"
import './App.css'
function App() {
  function UsuarioList(){
    const usuario = Usuario.data.find(u => u.idUser === 11)
    return (
      <div>
        <h1>{usuario?.name}</h1>
        <h2>{usuario?.cellPhone}</h2>
        <p>Altura y Direccion</p>
        <p>{usuario?.userProfiles.localidad.Number}</p>
        <p>{usuario?.userProfiles.localidad.Street}</p>
      </div>
    )
  }
  return (
    <div>
        {UsuarioList()}
    </div>
  )
}

export default App
