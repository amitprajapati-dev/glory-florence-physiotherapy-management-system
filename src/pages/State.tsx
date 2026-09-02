import { useEffect, useState } from 'react';

type State = {
  id: number;
  countryId: number;
  name: string;
  code: string;
  isActive: boolean;
};

function State() {

  const [states, setStates] = useState<State[]>([]);

  const [countryId, setCountryId] = useState('');
  const [name, setName] = useState('');
  const [code, setCode] = useState('');
  const [isActive, setIsActive] = useState(true);

  const [editId, setEditId] = useState<number | null>(null);


  // Get All States
  useEffect(() => {

    fetch('http://localhost:5142/api/States')
      .then((response) => response.json())
      .then((data) => {
        setStates(data);
      });

  }, []);


  // Add / Update
  const handleSubmit = async (
    e: React.SubmitEvent<HTMLFormElement>
  ) => {

    e.preventDefault();

    if (!countryId || !name.trim() || !code.trim()) {
      return;
    }


    // UPDATE
    if (editId !== null) {

      const response = await fetch(
        `http://localhost:5142/api/States/${editId}`,
        {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            id: editId,
            countryId: Number(countryId),
            name: name,
            code: code,
            isActive: isActive
          }),
        }
      );


      if (!response.ok) {
        console.log('Failed to update State');
        return;
      }


      const updatedState = await response.json();


      setStates(
        states.map((state) =>
          state.id === editId
            ? updatedState
            : state
        )
      );


      handleReset();
    }


    // ADD
    else {

      const response = await fetch(
        'http://localhost:5142/api/States',
        {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            countryId: Number(countryId),
            name: name,
            code: code,
            isActive: isActive
          }),
        }
      );


      if (!response.ok) {
        console.log('Failed to add State');
        return;
      }


      fetch('http://localhost:5142/api/States')
        .then((response) => response.json())
        .then((data) => {
          setStates(data);
        });


      handleReset();
    }

  };


  // Edit State
  const handleEdit = (id: number) => {

    const state = states.find(
      (state) => state.id === id
    );

    if (!state) return;

    setCountryId(String(state.countryId));
    setName(state.name);
    setCode(state.code);
    setIsActive(state.isActive);

    setEditId(state.id);
  };


  // Delete State
  const handleDelete = async (id: number) => {

    const response = await fetch(
      `http://localhost:5142/api/States/${id}`,
      {
        method: 'DELETE',
      }
    );


    if (!response.ok) {
      console.log('Failed to delete State');
      return;
    }


    setStates(
      states.filter(
        (state) => state.id !== id
      )
    );
  };


  // Reset
  const handleReset = () => {

    setCountryId('');
    setName('');
    setCode('');
    setIsActive(true);
    setEditId(null);
  };


  return (
    <div className="container-fluid px-5 mt-4">

      <h2 className="text-center mb-4">
        Manage States
      </h2>


      <form onSubmit={handleSubmit}>

        {/* Country Id */}
        <div className="mb-3">

          <label className="form-label">
            Country Id
          </label>

          <input
            type="number"
            placeholder="Enter Country Id"
            className="form-control"
            value={countryId}
            onChange={(e) => setCountryId(e.target.value)}
          />

        </div>


        {/* State Name */}
        <div className="mb-3">

          <label className="form-label">
            State Name
          </label>

          <input
            type="text"
            placeholder="Enter State Name"
            className="form-control"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />

        </div>


        {/* State Code */}
        <div className="mb-3">

          <label className="form-label">
            State Code
          </label>

          <input
            type="text"
            placeholder="Enter State Code"
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
              ? 'Update State'
              : 'Add State'}
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


      {/* States Table */}
      <table className="table table-bordered mt-4">

        <thead>

          <tr>
            <th>Id</th>
            <th>Country Id</th>
            <th>Name</th>
            <th>Code</th>
            <th>Is Active</th>
            <th>Actions</th>
          </tr>

        </thead>


        <tbody>

          {states.map((state) => (

            <tr key={state.id}>

              <td>{state.id}</td>

              <td>{state.countryId}</td>

              <td>{state.name}</td>

              <td>{state.code}</td>

              <td>
                {state.isActive ? 'Yes' : 'No'}
              </td>

              <td>

                <button
                  onClick={() => handleEdit(state.id)}
                  className="btn btn-warning btn-sm me-2"
                >
                  Edit
                </button>


                <button
                  onClick={() => handleDelete(state.id)}
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

export default State;