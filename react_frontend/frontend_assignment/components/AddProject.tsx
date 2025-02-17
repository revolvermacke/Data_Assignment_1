"use client";

import React, { useEffect, useState } from "react";
import { useForm, useFieldArray } from "react-hook-form";
import { useRouter } from "next/navigation";
import {
  Form,
  FormField,
  FormItem,
  FormLabel,
  FormControl,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";

// API Endpoints
const API_URL = "https://localhost:7124/api/project";
const EMPLOYEE_API = "https://localhost:7124/api/employee";
const CUSTOMER_API = "https://localhost:7124/api/customer";
const SERVICE_API = "https://localhost:7124/api/service";

// Hårdkodade statusar
const statuses = [
  { id: 1, name: "Ej påbörjad" },
  { id: 2, name: "Pågående" },
  { id: 3, name: "Avslutad" },
];

// TypeScript Interfaces
interface Employee {
  id: number;
  firstName: string;
  lastName: string;
}

interface Customer {
  id: number;
  customerName: string;
}

interface AvailableService {
  id: number;
  name: string;
  price: number;
  unit: string;
}

interface SelectedService {
  serviceId: string; // Välj befintligt tjänste-ID från dropdown
  quantity: number;
  price: number;
}

interface ProjectFormData {
  title: string;
  endDate: string;
  employeeNameId: string;
  customerNameId: string;
  statusTypeId: string;
  services: SelectedService[];
}

const AddProjectForm = () => {
  const router = useRouter();
  const form = useForm<ProjectFormData>({
    defaultValues: {
      title: "",
      endDate: "",
      employeeNameId: "",
      customerNameId: "",
      statusTypeId: "",
      services: [], // Här lagras valda tjänster
    },
  });

  // useFieldArray för att hantera dynamiskt listan med tjänster
  const { fields, append, remove } = useFieldArray({
    control: form.control,
    name: "services",
  });

  const [employees, setEmployees] = useState<Employee[]>([]);
  const [customers, setCustomers] = useState<Customer[]>([]);
  const [availableServices, setAvailableServices] = useState<
    AvailableService[]
  >([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  // Hämta anställda, kunder och tjänster
  useEffect(() => {
    const fetchData = async () => {
      try {
        const [employeeRes, customerRes, serviceRes] = await Promise.all([
          fetch(EMPLOYEE_API).then((res) => res.json()),
          fetch(CUSTOMER_API).then((res) => res.json()),
          fetch(SERVICE_API).then((res) => res.json()),
        ]);

        console.log("✅ Employees API-response:", employeeRes);
        console.log("✅ Customers API-response:", customerRes);
        console.log("✅ Services API-response:", serviceRes);

        setEmployees(employeeRes.data || []);
        setCustomers(customerRes.data || []);
        setAvailableServices(serviceRes.data || []);
      } catch (err) {
        console.error("❌ API-fetch fel:", err);
        setError("Kunde inte hämta alternativ från API.");
      }
    };

    fetchData();
  }, []);

  const onSubmit = async (data: ProjectFormData) => {
    setLoading(true);
    setError(null);
    console.log("Skickad projektdata:", data); // Kontrollera att tjänsterna medföljer

    try {
      const response = await fetch(API_URL, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
      });

      if (!response.ok) {
        throw new Error("Kunde inte skapa projektet.");
      }

      router.push("/projects"); // Navigera tillbaka till projektlistan
    } catch (err) {
      console.error("Fel vid skapandet av projektet:", err);
      setError("Ett fel inträffade vid skapandet av projektet.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className="space-y-4 max-w-lg mx-auto p-6 bg-white shadow-md rounded-lg"
      >
        <h2 className="text-2xl font-bold mb-4">Skapa nytt projekt</h2>

        {error && <p className="text-red-500">{error}</p>}

        {/* Projekttitel */}
        <FormField
          control={form.control}
          name="title"
          rules={{ required: "Projekttitel är obligatoriskt" }}
          render={({ field }) => (
            <FormItem>
              <FormLabel>Projekttitel</FormLabel>
              <FormControl>
                <Input placeholder="Ange projekttitel" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Slutdatum */}
        <FormField
          control={form.control}
          name="endDate"
          rules={{ required: "Slutdatum är obligatoriskt" }}
          render={({ field }) => (
            <FormItem>
              <FormLabel>Slutdatum</FormLabel>
              <FormControl>
                <Input type="date" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Projektansvarig (dropdown) */}
        <FormField
          control={form.control}
          name="employeeNameId"
          rules={{ required: "Vänligen välj en projektansvarig" }}
          render={({ field }) => (
            <FormItem>
              <FormLabel>Projektansvarig</FormLabel>
              <FormControl>
                <Select onValueChange={field.onChange} value={field.value}>
                  <SelectTrigger>
                    <SelectValue placeholder="Välj ansvarig" />
                  </SelectTrigger>
                  <SelectContent className="bg-white text-black border border-gray-300 shadow-lg z-50">
                    <SelectGroup>
                      {employees.map((emp) => (
                        <SelectItem key={emp.id} value={emp.id.toString()}>
                          {`${emp.firstName} ${emp.lastName}`}
                        </SelectItem>
                      ))}
                    </SelectGroup>
                  </SelectContent>
                </Select>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Kund (dropdown) */}
        <FormField
          control={form.control}
          name="customerNameId"
          rules={{ required: "Vänligen välj en kund" }}
          render={({ field }) => (
            <FormItem>
              <FormLabel>Kund</FormLabel>
              <FormControl>
                <Select onValueChange={field.onChange} value={field.value}>
                  <SelectTrigger>
                    <SelectValue placeholder="Välj kund" />
                  </SelectTrigger>
                  <SelectContent className="bg-white text-black border border-gray-300 shadow-lg z-50">
                    <SelectGroup>
                      {customers.map((cust) => (
                        <SelectItem key={cust.id} value={cust.id.toString()}>
                          {cust.customerName}
                        </SelectItem>
                      ))}
                    </SelectGroup>
                  </SelectContent>
                </Select>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Status (dropdown) */}
        <FormField
          control={form.control}
          name="statusTypeId"
          rules={{ required: "Vänligen välj en status" }}
          render={({ field }) => (
            <FormItem>
              <FormLabel>Status</FormLabel>
              <FormControl>
                <Select onValueChange={field.onChange} value={field.value}>
                  <SelectTrigger>
                    <SelectValue placeholder="Välj status" />
                  </SelectTrigger>
                  <SelectContent className="bg-white text-black border border-gray-300 shadow-lg z-50">
                    <SelectGroup>
                      {statuses.map((status) => (
                        <SelectItem
                          key={status.id}
                          value={status.id.toString()}
                        >
                          {status.name}
                        </SelectItem>
                      ))}
                    </SelectGroup>
                  </SelectContent>
                </Select>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Tjänster (Dropdown för befintliga tjänster) */}
        <div>
          <h3 className="text-xl font-semibold mt-4">Tjänster</h3>
          {fields.map((field, index) => (
            <div
              key={field.id}
              className="flex flex-col space-y-2 border p-2 rounded mb-2"
            >
              {/* Dropdown för att välja befintlig tjänst */}
              <FormField
                control={form.control}
                name={`services.${index}.serviceId` as const}
                rules={{ required: "Vänligen välj en tjänst" }}
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Tjänst</FormLabel>
                    <FormControl>
                      <Select
                        onValueChange={(value) => {
                          field.onChange(value);
                          // Hitta vald tjänst i availableServices
                          const foundSvc = availableServices.find(
                            (svc) => svc.id === parseInt(value)
                          );
                          if (foundSvc) {
                            // Sätt priset automatiskt i formuläret, utan att visa ett eget inputfält
                            form.setValue(
                              `services.${index}.price`,
                              foundSvc.price
                            );
                          }
                        }}
                        value={field.value}
                      >
                        <SelectTrigger>
                          <SelectValue placeholder="Välj tjänst" />
                        </SelectTrigger>
                        <SelectContent className="bg-white text-black border border-gray-300 shadow-lg z-50">
                          <SelectGroup>
                            {availableServices.map((svc) => (
                              <SelectItem
                                key={svc.id}
                                value={svc.id.toString()}
                              >
                                {svc.name} ({svc.unit}, {svc.price} SEK)
                              </SelectItem>
                            ))}
                          </SelectGroup>
                        </SelectContent>
                      </Select>
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              {/* Input för antal */}
              <FormField
                control={form.control}
                name={`services.${index}.quantity` as const}
                rules={{ required: "Ange antal" }}
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Antal</FormLabel>
                    <FormControl>
                      <Input
                        type="number"
                        placeholder="Ange antal"
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <Button variant="destructive" onClick={() => remove(index)}>
                Ta bort tjänst
              </Button>
            </div>
          ))}
          <Button
            onClick={() => append({ serviceId: "", quantity: 1, price: 0 })}
          >
            Lägg till tjänst
          </Button>
        </div>

        <Button type="submit" disabled={loading}>
          {loading ? "Skapar..." : "Skapa Projekt"}
        </Button>
      </form>
    </Form>
  );
};

export default AddProjectForm;
