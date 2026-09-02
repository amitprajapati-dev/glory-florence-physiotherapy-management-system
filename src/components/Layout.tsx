import type { ReactNode } from 'react';
import { Link } from 'react-router-dom';

function Layout({ children }: { children: ReactNode }) {
  return (
    <div className="container-fluid">
      <div className="row min-vh-100">

        {/* Sidebar */}
        <nav className="col-12 col-md-3 col-lg-2 border-end p-3" style={{ backgroundColor: '#18181b' }}>
          <div className="d-flex flex-column gap-5 text-white mt-5">
            <Link to="/city" className="text-decoration-none text-white">
              City
            </Link>

            <Link to="/country" className="text-decoration-none text-white">
              Country
            </Link>

            <Link to="/state" className="text-decoration-none text-white">
              State
            </Link>
          </div>
        </nav>

        {/* Main Content */}
        <main className="col-12 col-md-9 col-lg-10 p-4">
          {children}
        </main>
      </div>
    </div>
  );
}

export default Layout;