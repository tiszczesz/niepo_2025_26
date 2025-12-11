import { useEffect, useState } from "react"
import { getAll } from "../models/services"
import type { User } from "../models/types"

type Props = {}

const UsersList = (props: Props) => {
    const [users, setUsers] = useState<User[]>([])
    let lp = 0;
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
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Lp</th>
                        <th>Username</th>
                        <th>Email</th>
                        <th>Data dodania</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>

                    {users.map((elem) => (
                        <tr key={elem.id}>
                            <td>{++lp}</td>
                            <td>{elem.userName}</td>
                            <td>
                                {elem.email}
                            </td>
                            <td>
                                {new Date(elem.createdAt).toLocaleDateString()}
                            </td>
                            <td>
                                <button className="btn btn-sm btn-danger">Usuń</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </>
    )
}

export default UsersList