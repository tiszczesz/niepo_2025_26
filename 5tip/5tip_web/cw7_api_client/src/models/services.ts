import type { User } from "./types";

export const getAll = async () => {
    const  resp = await fetch('http://localhost:5048/api/users/');
    return (await resp.json()) as User[];
}