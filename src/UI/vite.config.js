import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

// Backend aus src/Api (launchSettings: http://localhost:5111)
const apiTarget = process.env.API_URL ?? "http://localhost:5111";

export default defineConfig({
  plugins: [react()],
  server: {
    port: 8080,
    proxy: {
      "/api": { target: apiTarget, changeOrigin: true },
    },
    watch: { ignored: ["**/*.fs"] },
  },
  build: {
    outDir: "dist",
    emptyOutDir: true,
  },
});
