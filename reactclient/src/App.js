import { Home, Playground } from "./pages/pages-export"
import { Routes, Route } from "react-router-dom"

export default function App() {
  return (
    <Routes>
      <Route path="/" element={ <Home /> }/>
      <Route path="/playground" element={ <Playground /> }/>
    </Routes>
  );
}
