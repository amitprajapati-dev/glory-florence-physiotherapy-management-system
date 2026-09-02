import { useEffect, useState } from 'react';

type Country = {
  id: number;
  name: string;
  code: string;
  isActive: boolean;
};

function Country() {

  const [countries, setCountries] = useState<Country[]>([]);

  const [name, setName] = useState('');
  const [code, setCode] = useState('');
  const [isActive, setIsActive] = useState(true);

  const [editId, setEditId] = useState<number | null>(null);


  // Get All Countries
  useEffect(() => {
    fetch('http://localhost:5142/api/Countries')
      .then((response) => response.json())
      .then((data) => {
        setCountries(data);
      });
  }, []);


  // Add / Update
  const handleSubmit = async (e: React.SubmitEvent<HTMLFormElement>) => {

    e.preventDefault();

    if (!name.trim() || !code.trim()) {
      return;
    }


    // UPDATE
    if (editId !== null) {

      const response = await fetch(
        `http://localhost:5142/api/Countries/${editId}`,
        {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            id: editId,
            name: name,
            code: code,
            isActive: isActive
          }),
        }
      );


      if (!response.ok) {
        console.log("Failed to update Country");
        return;
      }


      const updatedCountry = await response.json();


      setCountries(
        countries.map((country) =>
          country.id === editId
            ? updatedCountry
            : country
        )
      );


      handleReset();
    }


    // ADD
    else {

      const response = await fetch(
        'http://localhost:5142/api/Countries',
        {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            name: name,
            code: code,
            isActive: isActive
          }),
        }
      );


      if (!response.ok) {
        console.log("Failed to add Country");
        return;
      }

      fetch('http://localhost:5142/api/Countries')
        .then((response) => response.json())
        .then((data) => {
          setCountries(data);
        });

      handleReset();
    }
  };


  // Edit Country
  const handleEdit = (id: number) => {

    const country = countries.find(
      (country) => country.id === id
    );

    if (!country) return;

    setName(country.name);
    setCode(country.code);
    setIsActive(country.isActive);

    setEditId(country.id);
  };


  // Delete Country
  const handleDelete = async (id: number) => {

    const response = await fetch(
      `http://localhost:5142/api/Countries/${id}`,
      {
        method: 'DELETE',
      }
    );


    if (!response.ok) {
      console.log("Failed to delete Country");
      return;
    }


    setCountries(
      countries.filter(
        (country) => country.id !== id
      )
    );
  };


  // Reset
  const handleReset = () => {

    setName('');
    setCode('');
    setIsActive(true);
    setEditId(null);
  };


  return (
    <div className="container-fluid px-5 mt-4">

      <h2 className="text-center mb-4">
        Manage Countries
      </h2>


      <form onSubmit={handleSubmit}>

        {/* Country Name */}
        <div className="mb-3">

          <label className="form-label">
            Country Name
          </label>

          <input
            type="text"
            placeholder="Enter Country Name"
            className="form-control"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />

        </div>


        {/* Country Code */}
        <div className="mb-3">

          <label className="form-label">
            Country Code
          </label>

          <input
            type="text"
            placeholder="Enter Country Code"
            className="form-control"
            value={code}
            onChange={(e) => setCode(e.target.value)}
          />

        </div>


        {/* Is Active */}
        <div className="mb-3 form-check">

          <input
            type="checkbox"
            className="form-check-input"
            checked={isActive}
            onChange={(e) => setIsActive(e.target.checked)}
          />

          <label className="form-check-label">
            Is Active
          </label>

        </div>


        {/* Buttons */}
        <div className="mt-3 d-flex gap-2">

          <button
            type="submit"
            className="btn text-white"
            style={{ backgroundColor: '#2563eb' }}
          >
            {editId !== null
              ? 'Update Country'
              : 'Add Country'}
          </button>


          <button
            type="button"
            onClick={handleReset}
            className="btn text-white"
            style={{ backgroundColor: '#6b7280' }}
          >
            Reset
          </button>

        </div>

      </form>


      {/* Countries Table */}
      <table className="table table-bordered mt-4">

        <thead>

          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Code</th>
            <th>Is Active</th>
            <th>Actions</th>
          </tr>

        </thead>


        <tbody>

          {countries.map((country) => (

            <tr key={country.id}>

              <td>{country.id}</td>

              <td>{country.name}</td>

              <td>{country.code}</td>

              <td>
                {country.isActive ? 'Yes' : 'No'}
              </td>

              <td>

                <button
                  onClick={() => handleEdit(country.id)}
                  className="btn btn-warning btn-sm me-2"
                >
                  Edit
                </button>


                <button
                  onClick={() => handleDelete(country.id)}
                  className="btn btn-danger btn-sm"
                >
                  Delete
                </button>

              </td>

            </tr>

          ))}

        </tbody>

      </table>

    </div>
  );
}

export default Country;