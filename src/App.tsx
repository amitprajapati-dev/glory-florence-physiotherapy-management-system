import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Layout from './components/Layout';
import City from './pages/City';
import Country from './pages/Country'
import State from './pages/State'

function App() {
  return (
    <Router>
      <Layout>
        <Routes>
          <Route path="/city" element={<City />} />
          <Route path="/country" element={<Country />} />
          <Route path="/state" element={<State />} />
        </Routes>
      </Layout>
    </Router>
  );
}

export default App;