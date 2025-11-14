import http, { IncomingMessage, ServerResponse } from 'http';
import { handleRoutes } from './routes.js';
//pierwsze podejście do serwera http w nodejs z typescriptem
const server = http.createServer(handleRoutes);
//nasłuchiwanie na porcie 3000
const PORT = 3000;
server.listen(PORT, () => {
    console.log(`Server running at http://localhost:${PORT}/`);
});
//# sourceMappingURL=server.js.map