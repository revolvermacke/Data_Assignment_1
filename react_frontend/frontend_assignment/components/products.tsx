"use client";

import { Button } from "@/components/ui/button";
import { useEffect, useState } from "react";

type Product = {
  id: number;
  title: string;
  description: string;
};

export default function Products() {
  const [data, setData] = useState<Product[] | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const res = await fetch("https://dummyjson.com/products");
        if (!res.ok) {
          throw new Error("Something went wrong");
        }
        const result = await res.json();
        setData(result.products);
      } catch (error: unknown) {
        if (error instanceof Error) {
          setError(error.message);
        } else {
          setError("An unknown error occurred");
        }
      } finally {
        setLoading(false);
      }
    };

    fetchProducts();
  }, []);

  return (
    <div className="mt-6">
      <h2 className="text-2xl">Produkter</h2>

      {loading && <p className="text-gray-500">Loading...</p>}
      {error && <p className="text-red-500">{error}</p>}

      {data && (
        <ul className="mt-4 max-w-md">
          {data.map((product) => (
            <li key={product.id} className="border p-4 rounded shadow-sm mb-2">
              <h3 className="font-bold">{product.title}</h3>
              <p className="text-gray-700">{product.description}</p>
            </li>
          ))}
        </ul>
      )}

      <Button variant="outline" size="sm">
        Klicka här
      </Button>
    </div>
  );
}
