import { useEffect, useState } from 'react';

type City = {
  id: number;
  stateId: number;
  name: string;
  pinCode: string;
  isActive: boolean;
};

function City() {

  const [cities, setCities] = useState<City[]>([]);

  const [stateId, setStateId] = useState('');
  const [name, setName] = useState('');
  const [pinCode, setPinCode] = useState('');
  const [isActive, setIsActive] = useState(true);

  const [editId, setEditId] = useState<number | null>(null);

  // Get All Cities
  useEffect(() => {
    fetch('http://localhost:5142/api/Cities')
      .then((response) => response.json())
      .then((data) => {
        setCities(data);
      });
  }, []);

  // Add / Update
  const handleSubmit = async (e: React.SubmitEvent<HTMLFormElement>) => {
    e.preventDefault();

    if (!name.trim() || !stateId || !pinCode.trim()) return;

    // Update City
    if (editId !== null) {

      const response = await fetch(
        `http://localhost:5142/api/Cities/${editId}`,
        {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            id: editId,
            stateId: Number(stateId),
            name: name,
            pinCode: pinCode,
            isActive: isActive
          }),
        }
      );

      if (!response.ok) {
        console.log("Failed to update City");
        return;
      }

      const updatedCity = await response.json();

      setCities(
        cities.map((city) =>
          city.id === editId
            ? updatedCity
            : city
        )
      );

      setEditId(null);
    }

    // Add City
    else {

      const response = await fetch(
        'http://localhost:5142/api/Cities',
        {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            stateId: Number(stateId),
            name: name,
            pinCode: pinCode,
            isActive: isActive
          }),
        }
      );

      if (!response.ok) {
        console.log("Failed to add City");
        return;
      }

      fetch('http://localhost:5142/api/Cities')
        .then((response) => response.json())
        .then((data) => {
          setCities(data);
        });
    }

    handleReset();
  };

  // Edit City
  const handleEdit = (id: number) => {

    const city = cities.find(
      (city) => city.id === id
    );

    if (!city) return;

    setStateId(String(city.stateId));
    setName(city.name);
    setPinCode(city.pinCode);
    setIsActive(city.isActive);

    setEditId(city.id);
  };

  // Delete City
  const handleDelete = async (id: number) => {

    const response = await fetch(
      `http://localhost:5142/api/Cities/${id}`,
      {
        method: 'DELETE',
      }
    );

    if (!response.ok) {
      console.log("Failed to delete City");
      return;
    }

    setCities(
      cities.filter(
        (city) => city.id !== id
      )
    );
  };

  // Reset
  const handleReset = () => {
    setStateId('');
    setName('');
    setPinCode('');
    setIsActive(true);
    setEditId(null);
  };

  return (
    <div className="container-fluid px-5 mt-4">

      <h2 className="text-center mb-4">
        Manage Cities
      </h2>

      <form onSubmit={handleSubmit}>

        {/* State Id */}
        <div className="mb-3">
          <label className="form-label">
            State Id
          </label>

          <input
            type="number"
            placeholder="Enter State Id"
            className="form-control"
            value={stateId}
            onChange={(e) => setStateId(e.target.value)}
          />
        </div>

        {/* City Name */}
        <div className="mb-3">
          <label className="form-label">
            City Name
          </label>

          <input
            type="text"
            placeholder="Enter City Name"
            className="form-control"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </div>

        {/* Pin Code */}
        <div className="mb-3">
          <label className="form-label">
            Pin Code
          </label>

          <input
            type="text"
            placeholder="Enter Pin Code"
            className="form-control"
            value={pinCode}
            onChange={(e) => setPinCode(e.target.value)}
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
            {editId !== null ? 'Update City' : 'Add City'}
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

      {/* Cities Table */}
      <table className="table table-bordered mt-4">

        <thead>
          <tr>
            <th>Id</th>
            <th>State Id</th>
            <th>Name</th>
            <th>Pin Code</th>
            <th>Is Active</th>
            <th>Actions</th>
          </tr>
        </thead>

        <tbody>

          {cities.map((city) => (

            <tr key={city.id}>

              <td>{city.id}</td>

              <td>{city.stateId}</td>

              <td>{city.name}</td>

              <td>{city.pinCode}</td>

              <td>
                {city.isActive ? 'Yes' : 'No'}
              </td>

              <td>

                <button
                  onClick={() => handleEdit(city.id)}
                  className="btn btn-warning btn-sm me-2"
                >
                  Edit
                </button>

                <button
                  onClick={() => handleDelete(city.id)}
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

export default City;