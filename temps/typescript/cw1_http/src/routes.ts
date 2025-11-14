import { IncomingMessage,ServerResponse } from "http";
import fs from "fs";

export const handleRoutes = (req: IncomingMessage, res: ServerResponse) => {
    if (req.url === "/") {
        res.statusCode = 200;
        res.setHeader("Content-Type", "text/plain");
        return res.end("Hello, World!\n");
        
    } else if (req.url === "/about") {
        res.statusCode = 200;
        res.setHeader("Content-Type", "text/plain");
        return res.end("About Page\n");
    }
};