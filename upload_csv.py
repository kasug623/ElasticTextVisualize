import argparse
from elasticsearch import Elasticsearch
import csv

def upload_csv_to_elasticsearch(index_name, csv_file_path, host, port, protocol,  username, password):

    # Initialize the Elasticsearch client with Basic Authentication
    es = Elasticsearch([{'host': host, 'port': port, 'scheme': protocol}],
                        basic_auth=(username, password))

    with open(csv_file_path, 'r', encoding='utf-8') as file:
        csv_reader = csv.DictReader(file)
        for row in csv_reader:
            # Index documents in Elasticsearch
            es.index(index=index_name, body=row)

def main():
    parser = argparse.ArgumentParser(description="Upload a CSV file to Elasticsearch with Basic Authentication")
    parser.add_argument("csv_file", help="Path to the CSV file to upload")
    parser.add_argument("index_name", help="Name of the Elasticsearch index to use")
    parser.add_argument("--host", default="localhost", help="Elasticsearch host (default: localhost)")
    parser.add_argument("--port", type=int, default=9200, help="Elasticsearch port (default: 9200)")
    parser.add_argument("--protocol", default="http", help="Elasticsearch protocol (default: http)")
    parser.add_argument("--username", required=True, help="Elasticsearch username")
    parser.add_argument("--password", required=True, help="Elasticsearch password")

    args = parser.parse_args()

    print(f"Uploading CSV file '{args.csv_file}' to Elasticsearch index '{args.index_name}'")

    upload_csv_to_elasticsearch(args.index_name, args.csv_file, args.host, args.port, args.protocol, args.username, args.password)

if __name__ == '__main__':
    main()
