import { useEffect, useState } from "react"
import { getAll } from "../models/services"
import type { User } from "../models/types"

type Props = {}

const UsersList = (props: Props) => {
    const [users, setUsers] = useState<User[]>([])
    useEffect(() => {
        (async () => {
            const users = await getAll();
            console.log(users);
            setUsers(users)
        })()
    }, [])
    return (
        <>
        <div>UsersList</div>
        <ul>
            {users.map((elem)=>(
                <li key={elem.id}>
                    {elem.userName} adres: {elem.email}
                    data rejestracji {elem.createdAt}
                </li>
            ))}
        </ul>
        </>
    )
}

export default UsersList