import { Outlet, NavLink } from "react-router"

const Layout = () => {
    return (
        <div>
            <header>
                <nav className="navbar navbar-expand-lg navbar-light bg-light">
                    <ul className="nav-list navbar-nav gap-5">
                        <li className="nav-item">
                            <NavLink
                                className={({ isActive }) => (isActive ? "active" : "noActive")}
                                to="/">Home</NavLink>
                        </li>
                        <li className="nav-item">
                            <NavLink
                                className={({ isActive }) => (isActive ? "active" : "noActive")}
                                to="/about">About</NavLink>
                        </li>
                        <li className="nav-item">
                            <NavLink to="/contacts"
                                className={({ isActive }) => (isActive ? "active" : "noActive")}
                            >Contacts</NavLink>
                        </li>
                    </ul>
                </nav>
            </header>
            <main className="container mt-4 bg-light p-4 rounded shadow"
            style={{ minHeight: '80vh' }}>
                <Outlet />
            </main>
            <footer>
                <p>&copy; 2025 Fajna aplikacja</p>
            </footer>
        </div>
    )
}

export default Layout   