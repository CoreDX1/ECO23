import axios, { AxiosResponse } from 'axios';
import { IUserById} from './Interfaces/IUsuarios';
import { useEffect, useState } from 'react';
import './App.css'

function App() {

  const [user, setUser] = useState<IUserById>() ;

  async function GetUser(): Promise<IUserById> {
    const { data }: AxiosResponse<IUserById> = await axios.get('http://localhost:5086/api/User/list/65');
    
    return data;
  }
  console.log(user);

  useEffect(() => {
    GetUser(
    );
  }, [])

  function RenderUser (){
    return (
      user.isSuccess ? (
        <div>
          <h1>{user.data.name}</h1>
        </div>
      ) : (
        <div>
          <h1>{user.message}</h1>
        </div>
      )
    )
  }

  return (
    <div>
      {RenderUser()}
    </div>
  )
}

export default App
