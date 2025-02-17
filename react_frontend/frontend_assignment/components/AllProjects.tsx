"use client";

import { useEffect, useState } from "react";
import { useRouter } from "next/navigation";

type Service = {
  id: number;
  name: string;
  price: number;
  unit: string;
  quantity: number;
};

type Project = {
  id: number;
  title: string;
  endDate: string;
  employeeName: string;
  customerName: string;
  statusType: string;
  services?: Service[];
} & Record<string, string | number | boolean | null | Service[]>;

const fieldTranslations: Record<string, string> = {
  employeeName: "Ansvarig",
  customerName: "Kund",
  statusType: "Status",
  services: "Tjänster",
};

export default function AllProjects() {
  const [projects, setProjects] = useState<Project[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const router = useRouter();

  useEffect(() => {
    const fetchProjects = async () => {
      try {
        const res = await fetch("https://localhost:7124/api/project");
        const result = await res.json();

        console.log("API Response:", result); // Debugga API-svaret

        if (result.data && Array.isArray(result.data)) {
          setProjects(result.data);
        } else {
          console.error("API returned an object instead of an array:", result);
          setProjects([]);
        }
      } catch (error) {
        console.error("Fetch error:", error);
        setError("Kunde inte ladda projekt.");
      } finally {
        setLoading(false);
      }
    };

    fetchProjects();
  }, []);

  // Logga ut projekten varje gång de ändras
  useEffect(() => {
    console.log("Projects loaded:", projects);
  }, [projects]);

  const handleEdit = (id: number) => {
    router.push(`/projects/edit/${id}`);
  };

  const handleDelete = async (id: number) => {
    const confirmDelete = confirm(
      "Är du säker på att du vill ta bort detta projekt?"
    );
    if (!confirmDelete) return;

    try {
      const res = await fetch(`https://localhost:7124/api/project/${id}`, {
        method: "DELETE",
      });
      if (!res.ok) {
        throw new Error("Fel vid radering av projektet");
      }
      // Uppdatera listan lokalt efter lyckad radering
      setProjects((prev) => prev.filter((project) => project.id !== id));
    } catch (err) {
      console.error(err);
      alert("Kunde inte ta bort projektet");
    }
  };

  return (
    <div className="p-6">
      <h1 className="text-3xl font-bold mb-6">Alla Projekt</h1>

      {loading && <p className="text-gray-500">Laddar...</p>}
      {error && <p className="text-red-500">{error}</p>}

      {projects.length > 0 ? (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
          {projects.map((project) => (
            <div
              key={project.id}
              className="p-4 border rounded-lg shadow-md bg-white"
            >
              <h2 className="text-xl font-semibold">
                Projekt ID: {project.id}
              </h2>

              <ul className="text-gray-600 mt-2">
                {Object.entries(project).map(([key, value]) => {
                  if (key === "id") return null; // Hoppa över "id"

                  const translatedKey =
                    fieldTranslations[key] ||
                    key.replace(/([A-Z])/g, " $1").trim();

                  return (
                    <li key={key}>
                      <strong className="capitalize">{translatedKey}: </strong>
                      {key === "services" && Array.isArray(value) ? (
                        <ul className="ml-4 list-disc">
                          {value.map((service: Service) => (
                            <li key={service.id} className="mt-1">
                              <strong>{service.name}</strong> - {service.quantity}{" "}
                              {service.unit} à {service.price} SEK
                            </li>
                          ))}
                        </ul>
                      ) : typeof value === "string" &&
                        value.includes("00:00:00") ? (
                        new Date(value).toLocaleDateString()
                      ) : (
                        String(value)
                      )}
                    </li>
                  );
                })}
              </ul>

              {/* Redigera- och Radera-knappar */}
              <div className="mt-4 flex space-x-2 justify-center">
                <button
                  onClick={() => handleEdit(project.id)}
                  className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded"
                >
                  Editera
                </button>
                <button
                  onClick={() => handleDelete(project.id)}
                  className="bg-red-500 hover:bg-red-600 text-white px-4 py-2 rounded"
                >
                  Ta bort
                </button>
              </div>
            </div>
          ))}
        </div>
      ) : (
        !loading && <p className="text-gray-500">Inga projekt tillgängliga.</p>
      )}
    </div>
  );
}
