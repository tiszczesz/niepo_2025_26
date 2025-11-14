import type { IncomingMessage, ServerResponse } from "node:http";
import {type Book, books} from './data/my-books.js';
import { readFileSync } from "node:fs";

export const handleRoutes = (req: IncomingMessage, res: ServerResponse) => { 
    if(req.url === '/' && req.method === 'GET'){
        res.statusCode = 200;
        res.setHeader('Content-Type', 'text/plain');
        return res.end('Hello, world!');
    }else if(req.url==='/about' && req.method==='GET'){
        res.statusCode = 200;
        res.setHeader('Content-Type', 'text/html');
        return res.end('<h1>About Page</h1><p>lorem ipsum</p>');
    }else if(req.url === '/books' && req.method === 'GET'){
        res.statusCode = 200;
        res.setHeader('Content-Type', 'application/json');
        return res.end(JSON.stringify(books));
    }else if(req.url==='/index'){
        res.statusCode = 200;
        res.setHeader('Content-Type', 'text/html');
        const html = readFileSync('./public/index.html', 'utf-8');
        return res.end(html);
    }
    
    else{
        res.statusCode = 404;
        res.setHeader('Content-Type', 'text/html');
        return res.end('<h1>Not Found</h1>');
    }
};