# useEffect + asynchroniczny fetch (React / React + TypeScript)

## 1) Najprostszy przykład: fetch po mount (`[]`)

```tsx
import { useEffect, useState } from "react";

type User = {
  id: number;
  name: string;
  username: string;
  email: string;
};

export function UsersList() {
  const [users, setUsers] = useState<User[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    // Uwaga: w useEffect NIE robimy `async () => {}` bezpośrednio,
    // tylko tworzymy funkcję async w środku i ją wywołujemy.
    const load = async () => {
      try {
        setLoading(true);
        setError(null);

        const res = await fetch("https://jsonplaceholder.typicode.com/users");
        if (!res.ok) throw new Error(`HTTP ${res.status}`);

        const data: User[] = await res.json();
        setUsers(data);
      } catch (e) {
        setError(e instanceof Error ? e.message : "Unknown error");
      } finally {
        setLoading(false);
      }
    };

    load();
  }, []); // uruchom tylko raz po mount

  if (loading) return <p>Ładowanie...</p>;
  if (error) return <p>Błąd: {error}</p>;

  return (
    <ul>
      {users.map((u) => (
        <li key={u.id}>
          {u.name} ({u.email})
        </li>
      ))}
    </ul>
  );
}
```

## 2) Fetch zależny od parametru (np. `userId`)

```tsx
import { useEffect, useState } from "react";

type User = { id: number; name: string };

export function UserDetails({ userId }: { userId: number }) {
  const [user, setUser] = useState<User | null>(null);

  useEffect(() => {
    const load = async () => {
      const res = await fetch(
        `https://jsonplaceholder.typicode.com/users/${userId}`
      );
      const data: User = await res.json();
      setUser(data);
    };

    load();
  }, [userId]); // ponownie pobierz dane gdy zmieni się userId

  if (!user) return <p>Ładowanie usera...</p>;
  return <h3>{user.name}</h3>;
}
```

## 3) Ważne: anulowanie (cleanup) żeby nie ustawiać state po unmount

Gdy komponent zniknie zanim fetch się skończy, warto przerwać żądanie przez `AbortController`.

```tsx
import { useEffect, useState } from "react";

type Post = { id: number; title: string };

export function Posts() {
  const [posts, setPosts] = useState<Post[]>([]);

  useEffect(() => {
    const controller = new AbortController();

    const load = async () => {
      try {
        const res = await fetch(
          "https://jsonplaceholder.typicode.com/posts",
          {
            signal: controller.signal,
          }
        );
        const data: Post[] = await res.json();
        setPosts(data);
      } catch (e) {
        // AbortError jest OK (to nie „błąd aplikacji”)
        if (e instanceof DOMException && e.name === "AbortError") return;
        console.error(e);
      }
    };

    load();

    return () => {
      controller.abort(); // cleanup
    };
  }, []);

  return (
    <ol>
      {posts.slice(0, 10).map((p) => (
        <li key={p.id}>{p.title}</li>
      ))}
    </ol>
  );
}
```

## 4) Najczęstsze błędy

1. **Brak tablicy zależności** -> fetch odpala się po każdym renderze (często pętla).
2. `useEffect(async () => { ... })` -> niby działa, ale jest antywzorcem (effect ma zwracać cleanup, nie Promise).
3. Brak anulowania -> warningi i wycieki gdy użytkownik szybko zmienia ekran.
