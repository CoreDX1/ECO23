import axios from 'axios';
import { IUsuario } from './Interfaces/IUsuarios';
import { useEffect, useState } from 'react';
import './App.css'

function App() {

  const [user, setUser] = useState<IUsuario>();

  async function GetUser(): Promise<void> {
    const { data } = await axios.get<IUsuario>('http://localhost:5086/api/User/list');
    setUser(data);
  }

  useEffect(() => {
    GetUser();
  }, [])

  return (
    <div>
      <h1>Cantidad De Usuarios {user?.data.length}</h1>
      {user?.message}
      {user?.data.map(item => (
        <div key={item.idUser}>
          <p>Nombre del : {item.name} </p>
          <p>Numero de la casa : {item.userProfile.location.street}</p>
        </div>
      ))}
    </div>
  )
}

export default App
