import Table from 'react-bootstrap/Table';
import { useState } from 'react';
import { useEffect } from 'react';

import axios from "axios"



const UserTable = ({path}) => {

    const [users, setUsers] = useState(null);

    useEffect(()  =>  {
        
    async function fetchData() {
        await axios.get('https://localhost:7050/api/'+path)
      .then(async (response) => setUsers( await response.data));
    }
    
    fetchData();

    },[]);
  
    const mapExperienceLevel = (level)=>{

        switch(level){
            case 0: {
                return "Intern";
            }
            case 1: {
                return "Junior";
            }
            case 2: {
                return "Middle";
            }
            case 3: {
                return "Senior";
            }
        }
    }


    const createUsers = (users) => {
        
        return users?.map((t, i) => (
            <tr>
                <td>
                    {i + 1}
                </td>
                <td>
                    {t.id}
                </td>
                <td>
                    {t.name}
                </td>
                <td>
                    {t.surname}
                </td>
                <td>
                    {t.developerDirection}
                </td>
                <td>
                    {mapExperienceLevel(t.experienceLevel)}
                </td>
            </tr>
        ) ) ;
    }
    return(
        <>     
        
       
        <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Surname</th>
                        <th>Developer direction</th>
                        <th>Experience level</th>
                    </tr>
                </thead>
                <tbody>
                    {createUsers(users)}
                </tbody>
            </Table>    
        
            
        </>
    );
}

export default UserTable;